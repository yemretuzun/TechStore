using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SharedModels.FormInputs;


namespace TechStoreWebApp
{
    

    public class UserManager : IUserManager
    {
        private readonly Services.Services _services;

        public UserManager()
        {
            _services = new Services.Services();
        }

        public async Task<SignUpResult> SignUp(RegisterInput newUser, string credentialTypeCode, string identifier)
        {
            return await SignUp(newUser, credentialTypeCode, identifier, null);
        }

        public async Task<SignUpResult> SignUp(RegisterInput newUser, string credentialTypeCode, string identifier, string secret)
        {
            // Api a request göndererek yeni kullanıcı oluştur.
            var user = await _services.UserService.Register(newUser);

            var credentialTypes =  _services.CredentialTypesService.GetAll();
            var credentialType = credentialTypes.FirstOrDefault(ct => ct.Code.ToLower() == credentialTypeCode.ToLower());

            if (credentialType == null) 
                return new SignUpResult(success: false, error: SignUpResultError.CredentialTypeNotFound);

            var credential = new Credential
            {
                UserId = user.Id, 
                CredentialTypeId = credentialType.Id, 
                Identifier = identifier
            };

            if (!string.IsNullOrEmpty(secret))
            {
                var salt = Pbkdf2Hasher.GenerateRandomSalt();
                var hash = Pbkdf2Hasher.ComputeHash(secret, salt);

                credential.Secret = hash;
                credential.Extra = Convert.ToBase64String(salt);
            }

            _services.CredentialService.Create(credential);

            return new SignUpResult(user: user, success: true);
        }


        public void AddToRole(User user, string roleCode)
        {
            var roles =  _services.RoleService.GetAll();
            var role = roles.FirstOrDefault(r => r.Code.ToLower() ==  roleCode.ToLower());

            if (role == null)
              return;

            AddToRole(user, role);
        }

        public void AddToRole(User user, Role role)
        {
            var userRoles = _services.UserRoleService.GetAll();
            var userRole = userRoles.Find(x => x.UserId == user.Id && x.RoleId == role.Id);

            if (userRole != null)
              return;

            userRole = new UserRole
            {
                UserId = user.Id, 
                RoleId = role.Id
            };
            
             _services.UserRoleService.Create(userRole);
        }

        public void RemoveFromRole(User user, string roleCode)
        {
            var roles =  _services.RoleService.GetAll();
            var role = roles.FirstOrDefault(r => r.Code.ToLower() == roleCode.ToLower());

            if (role == null)
                return;

            RemoveFromRole(user, role);
        }

        public void RemoveFromRole(User user, Role role)
        {
            var userRole = new UserRole()
            {
                UserId = user.Id,
                RoleId = role.Id
            };

            _services.UserRoleService.Remove(userRole);
        }

        public ChangeSecretResult ChangeSecret(string credentialTypeCode, string identifier, string secret)
        {
            var credentialTypes =_services.CredentialTypesService.GetAll();
            var credentialType = credentialTypes.FirstOrDefault(ct => ct.Code.ToLower() == credentialTypeCode.ToLower());

            if (credentialType == null)
              return new ChangeSecretResult(success: false, error: ChangeSecretResultError.CredentialTypeNotFound);

            var credentials = _services.CredentialService.GetAll();
            var credential = credentials.FirstOrDefault(c => c.CredentialTypeId == credentialType.Id && c.Identifier == identifier);

            if (credential == null)
              return new ChangeSecretResult(success: false, error: ChangeSecretResultError.CredentialNotFound);

            var salt = Pbkdf2Hasher.GenerateRandomSalt();
            var hash = Pbkdf2Hasher.ComputeHash(secret, salt);

            credential.Secret = hash;
            credential.Extra = Convert.ToBase64String(salt);

            _services.CredentialService.Update(credential);
            
            return new ChangeSecretResult(success: true);
        }

        public ValidateResult Validate(string credentialTypeCode, string identifier)
        {
            return Validate(credentialTypeCode, identifier, null);
        }

        public ValidateResult Validate(string credentialTypeCode, string identifier, string secret)
        {
            var credentialTypes =_services.CredentialTypesService.GetAll();
            var credentialType = credentialTypes.FirstOrDefault(ct => ct.Code.ToLower() == credentialTypeCode.ToLower());

            if (credentialType == null)
              return new ValidateResult(success: false, error: ValidateResultError.CredentialTypeNotFound);

            var credentials =  _services.CredentialService.GetAll();
            var credential = credentials.FirstOrDefault(c => c.CredentialTypeId == credentialType.Id && c.Identifier == identifier);

            if (credential == null)
              return new ValidateResult(success: false, error: ValidateResultError.CredentialNotFound);

            if (!string.IsNullOrEmpty(secret))
            {
              var salt = Convert.FromBase64String(credential.Extra);
              var hash = Pbkdf2Hasher.ComputeHash(secret, salt);

              if (credential.Secret != hash)
                return new ValidateResult(success: false, error: ValidateResultError.SecretNotValid);
            }

            var usr =  _services.UserService.GetById(credential.UserId);
            return new ValidateResult(user: usr, success: true);
        }

        public async void SignIn(HttpContext httpContext, User user, bool isPersistent = false)
        {
            var identity = new ClaimsIdentity(GetUserClaims(user), CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await httpContext.SignInAsync(
              CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties() { IsPersistent = isPersistent }
            );
        }

        public async void SignIn(HttpContext httpContext, LoginInput user, bool isPersistent = false)
        {
            var users =  _services.UserService.GetAll();
            var usr = users.Find(u => u.Email == user.Email);
            var identity = new ClaimsIdentity(GetUserClaims(usr), CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await httpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties() { IsPersistent = isPersistent }
            );
        }

        public async void SignOut(HttpContext httpContext)
        { 
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public string GetCurrentUserId(HttpContext httpContext)
        {
            if (httpContext.User.Identity != null && !httpContext.User.Identity.IsAuthenticated)
              return "";

            var claim = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (claim == null)
              return "";


            return claim.Value;
        }

        public User GetCurrentUser(HttpContext httpContext)
        {
            var currentUserId = GetCurrentUserId(httpContext);

            if (currentUserId == "")
              return null;

            var user =  _services.UserService.GetById(currentUserId);
            return user;
        }

        private IEnumerable<Claim> GetUserClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id), 
                new Claim(ClaimTypes.Name, user.FirstName)
            };

            claims.AddRange(GetUserRoleClaims(user));

            return claims;
        }

        private IEnumerable<Claim> GetUserRoleClaims(User user)
        {
            var claims = new List<Claim>();
            var userRoles =  _services.UserRoleService.GetAll();

            IEnumerable<string> roleIds = userRoles.Where(ur => ur.UserId == user.Id).Select(ur => ur.RoleId).ToList();

            if (roleIds.Any())
            {
                foreach (var roleId in roleIds)
                {
                  var role = _services.RoleService.GetById(roleId);

                  claims.Add(new Claim(ClaimTypes.Role, role.Code));
                  claims.AddRange(GetUserPermissionClaims(role));
                }
            }

            return claims;
        }

        private IEnumerable<Claim> GetUserPermissionClaims(Role role)
        {
            var claims = new List<Claim>();
            var rolePermissions = _services.RolePermissionService.GetAll();

            IEnumerable<string> permissionIds = rolePermissions.Where(rp => rp.RoleId == role.Id).Select(rp => rp.PermissionId).ToList();

            if (permissionIds.Any())
            {
                foreach (var permissionId in permissionIds)
                {
                    var permission = _services.PermissionService.GetById(permissionId);

                    claims.Add(new Claim("Permission", permission.Code));
                }
            }

            return claims;
        }
    }
}