using System.Threading.Tasks;
using TechStoreWebApp.Models;
using Microsoft.AspNetCore.Http;
using SharedModels;
using SharedModels.FormInputs;

namespace TechStoreWebApp
{
  public enum SignUpResultError
  {
    CredentialTypeNotFound,
    EmailExist
  }

  public class SignUpResult
  {
    public User User { get; set; }
    public bool Success { get; set; }
    public SignUpResultError? Error { get; set; }

    public SignUpResult(User user = null, bool success = false, SignUpResultError? error = null)
    {
        User = user;
        Success = success;
        Error = error;
    }
  }

  public enum ValidateResultError
  {
      CredentialTypeNotFound,
      CredentialNotFound,
      SecretNotValid
  }

  public class ValidateResult
  {
      public User User { get; set; }
      public bool Success { get; set; }
      public ValidateResultError? Error { get; set; }

      public ValidateResult(User user = null, bool success = false, ValidateResultError? error = null)
      {
        this.User = user;
        this.Success = success;
        this.Error = error;
      }
  }

  public enum ChangeSecretResultError
  {
      CredentialTypeNotFound,
      CredentialNotFound
  }

  public class ChangeSecretResult
  {
    public bool Success { get; set; }
    public ChangeSecretResultError? Error { get; set; }

    public ChangeSecretResult(bool success = false, ChangeSecretResultError? error = null)
    {
      this.Success = success;
      this.Error = error;
    }
  }

  public interface IUserManager
  {
    Task<SignUpResult> SignUp(RegisterInput user, string credentialTypeCode, string identifier);
    Task<SignUpResult> SignUp(RegisterInput user, string credentialTypeCode, string identifier, string secret);
    void AddToRole(User user, string roleCode);
    void AddToRole(User user, Role role);
    void RemoveFromRole(User user, string roleCode);
    void RemoveFromRole(User user, Role role);
    ChangeSecretResult ChangeSecret(string credentialTypeCode, string identifier, string secret);
    ValidateResult Validate(string credentialTypeCode, string identifier);
    ValidateResult Validate(string credentialTypeCode, string identifier, string secret);
    void SignIn(HttpContext httpContext, User user, bool isPersistent = false);
    void SignIn(HttpContext httpContext, LoginInput user, bool isPersistent = false);
    void SignOut(HttpContext httpContext);
    string GetCurrentUserId(HttpContext httpContext);
    User GetCurrentUser(HttpContext httpContext);
  }
}