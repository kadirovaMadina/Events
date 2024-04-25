namespace Contracts.Responses
{
    public record class SingleEventRegistrationResponse
    {
        public Guid Id { get; init; }
        public DateOnly RegistrationDate { get; init; }
        public bool Status { get; init; }
        public Guid EventId { get; init; }
        public Guid ParticipantId { get; init; }
    }
}
