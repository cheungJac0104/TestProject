﻿using System;
using Microsoft.Extensions.Options;

namespace TestProject.Middleware
{
	public class JwtMiddleware
	{
		private readonly RequestDelegate _next;

		public JwtMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{

		}
	}
}

