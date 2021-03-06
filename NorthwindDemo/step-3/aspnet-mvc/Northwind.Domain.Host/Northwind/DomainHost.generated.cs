﻿










//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#region Copyright
// -----------------------------------------------------------------------
// <copyright company="cdmdotnet Limited">
//     Copyright cdmdotnet Limited. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
#endregion

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using cdmdotnet.Logging;
using Cqrs.Ninject.Configuration;
using Northwind.Domain.Host.Configuration;
using Ninject.Modules;

namespace Northwind.Domain
{

	[GeneratedCode("CQRS UML Code Generator", "1.601.881")]
	public abstract partial class DomainHost<THostModule>
			where THostModule : NinjectModule, new()
	{
		public virtual void Configure()
		{
			Trace.TraceInformation("Starting configurations...");
			GetDomainConfiguration().Start();
			Trace.TraceInformation("Setting service point configurations...");
			new ServicePointManagerConfiguration().Start();

			Trace.TraceInformation("Data contracts configuring...");

			new Orders.Services.Host.OrderServiceHost().RegisterDataContracts();


			Trace.TraceInformation("Data contracts configured.");
		}

		protected virtual DomainConfiguration<THostModule> GetDomainConfiguration()
		{
			return new DomainConfiguration<THostModule>();
		}
		public virtual void Start()
		{
			LogApplicationStarted();

			Run();

			LogApplicationStopped();
		}

		protected abstract void Run();

		protected virtual ILogger GetLogger()
		{
			return NinjectDependencyResolver.Current.Resolve<ILogger>();
		}

		protected virtual void LogApplicationStarted()
		{
			try
			{
				ILogger logger = GetLogger();

				if (logger != null)
				{
					NinjectDependencyResolver.Current.Resolve<ICorrelationIdHelper>().SetCorrelationId(Guid.Empty);
					logger.LogInfo("Application started.", "LogApplicationStarted");
				}
			}
			catch { }
		}

		protected virtual void LogApplicationStopped()
		{
			try
			{
				ILogger logger = GetLogger();

				if (logger != null)
				{
					NinjectDependencyResolver.Current.Resolve<ICorrelationIdHelper>().SetCorrelationId(Guid.Empty);
					logger.LogInfo("Application stopped.", "LogApplicationStopped");
				}
			}
			catch { }
		}
	}
}
