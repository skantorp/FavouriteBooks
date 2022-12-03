﻿using Books.BusinessLogic.DTOs;
using MediatR;

namespace Books.BusinessLogic.Requests
{
	public class GetAllBooksRequest : IRequest<List<BookDTO>>
	{
	}
}