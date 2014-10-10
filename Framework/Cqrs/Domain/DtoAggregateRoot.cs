﻿using System;
using Cqrs.Events;

namespace Cqrs.Domain
{
	public class DtoAggregateRoot<TAuthenticationToken, TDto> : AggregateRoot<TAuthenticationToken>
		where TDto : IDto
	{
		public DtoAggregateRoot(Guid id, TDto original, TDto @new)
		{
			Id = id;
			ApplyChange(new DtoAggregateEvent<TAuthenticationToken, TDto>(id, original, @new));
		}
	}
}