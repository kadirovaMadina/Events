namespace Contracts.Requests
{
    public record class CreateEventRegistrationRequest
    {
        public DateOnly RegistrationDate { get; init; }
        public bool Status { get; init; }
        public Guid EventId { get; init; }
        public Guid ParticipantId { get; init; }
    }
}
