﻿namespace Victory.Domain.Features.API.ContactMessages;

public sealed record class GetContactMessageListQueryHandler
    : IRequestHandler<GetContactMessageListQuery, List<ContactMessageEntity>?>
{
    private readonly ApplicationContext _context;

    public GetContactMessageListQueryHandler(ApplicationContext context) => _context = context;

    public async Task<List<ContactMessageEntity>?> Handle(GetContactMessageListQuery request, CancellationToken token) =>
        await _context.ContactMessages.AsNoTracking().ToListAsync(cancellationToken: token);
}