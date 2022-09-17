using System.Collections.Generic;
using System.Net;

namespace JOS.Enumeration;

public enum ErrorTypes
{
    Undefined,
    Authorization,
    NotFound,
    Validation,
    Conflict,
    Gateway,
    Component,
    PartialSuccess
}

public record Error(ErrorTypes Type, string Message);

public record ValidationError(string Message) : Error(ErrorTypes.Validation, Message);

public record ResourceValidationError : ValidationError
{
    public ResourceValidationError(
        string resource,
        string message) : base(message)
    {
        Resource = resource;
    }

    public string Resource { get; }
}

public record NullOrEmptyError : ResourceValidationError
{
    public NullOrEmptyError(string resource) : base(
        resource, $"The property '{resource}' cannot be null or empty.")
    {
    }

    public NullOrEmptyError(string resource, string message) : base(resource, message) { }
}

public record NotFoundError(string ObjectType, string Id) : Error(
    ErrorTypes.NotFound,
    $"The {ObjectType} with id '{Id}' could not be found.");

public record PartialSuccessError(string message) : Error(
    ErrorTypes.PartialSuccess,
    message);

public record ValueTooLongError : ResourceValidationError
{
    public ValueTooLongError(
        string resource,
        string valueInformation,
        int actualLength,
        string unit,
        int maxLength) : base(resource, CreateMessage(valueInformation, actualLength, unit, maxLength))
    {
    }

    private static string CreateMessage(string valueInformation, int actualLength, string unit, int maxLength)
    {
        return $"The '{valueInformation}' is {actualLength} {unit} long which is too long, " +
               $"max length is {maxLength}";
    }
}

public record ValueToSmallError : ResourceValidationError
{
    public ValueToSmallError(
        string resource,
        string valueInformation,
        int actualLength,
        string unit,
        int minLength) : base(resource, CreateMessage(valueInformation, actualLength, unit, minLength))
    {
    }

    private static string CreateMessage(string valueInformation, int actualLength, string unit, int minLength)
    {
        return $"The '{valueInformation}' is {actualLength} {unit} long which is too short, " +
               $"min length is {minLength}";
    }
}

public record MissingRequiredResourceError : ValidationError
{
    public MissingRequiredResourceError(string resourceType, string resourceId) : base(
        CreateMessage(resourceType, resourceId))
    {
    }

    private static string CreateMessage(string resourceType, string resourceId)
    {
        return $"Required '{resourceType}' with Id '{resourceId}' does not exist";
    }
}

public record InvalidEmailError : ResourceValidationError
{
    public InvalidEmailError(string resource, string providedEmail) : base(
        resource, $"Provided email '{providedEmail}' is invalid")
    {
    }
}

public record InvalidMobilePhoneNumber : ResourceValidationError
{
    public InvalidMobilePhoneNumber(string resource, string providedPhoneNumber) : base(
        resource, $"Provided mobile phone number '{providedPhoneNumber}' is invalid. " +
                  "It needs to follow the international standard (starting with a +).")
    {
    }
}

public record MultipleValidationErrors(
    string Message,
    IEnumerable<ValidationErrorListItem> Errors) : ValidationError(
    Message);

public record ValidationErrorListItem(string PropertyName, IEnumerable<string> Errors);

public record DuplicateError(string TypeName, object PropertyValue) : Error(
    ErrorTypes.Conflict, $"'{PropertyValue}' already exists ({TypeName})");

public record GatewayResponseError(string Gateway, string Message) :
    Error(ErrorTypes.Gateway, $"{Gateway} returned an invalid response. Error message: {Message}");

public record HttpGatewayResponseError(HttpStatusCode StatusCode, string Gateway, string Message)
    : GatewayResponseError(Gateway, Message);

public record HealthCheckResponseError(string Component, string Message, string? Cause = null) :
    Error(ErrorTypes.Component, $"{Component} returned an invalid response. Error message: {Message}");

public record RebookingFailedToRetrieveNewAppointment(string Message)
    : PartialSuccessError(Message);
