using Raven.Client.Connection;

namespace Rvn.Izr.Adapters
{
	internal abstract class DbCommandsAdapter : IDatabaseCommands
	{
		private readonly IDatabaseCommands _commands;

		protected DbCommandsAdapter(IDatabaseCommands commands)
		{
			_commands = commands;
		}

		//TODO: delegate IDatabaseCommands implementation to _commands
	}
}