using Raven.Client;

namespace Rvn.Izr.Adapters
{
	internal abstract class DbSessionAdapter : IDocumentSession
	{
		private readonly IDocumentSession _session;

		protected DbSessionAdapter(IDocumentSession session)
		{
			_session = session;
		}

		public void Dispose()
		{
			_session.Dispose();
		}

		//TODO: delegate IDocumentSession implementation to _session
	}
}