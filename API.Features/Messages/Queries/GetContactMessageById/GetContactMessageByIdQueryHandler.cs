﻿namespace API.Features.Messages.Queries;

public sealed record class GetContactMessageByIdQueryHandler
    : IRequestHandler<GetContactMessageByIdQuery, ContactMessageEntity?>
{
    private readonly ApplicationContext _context;

    public GetContactMessageByIdQueryHandler(ApplicationContext context) => _context = context;

    public async Task<ContactMessageEntity?> Handle(GetContactMessageByIdQuery request, CancellationToken token) =>
        await _context.ContactMessages.FindAsync(
            keyValues: new object[] { request.Id },
            cancellationToken: token);
}