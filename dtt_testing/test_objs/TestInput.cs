using System;
using dtlibcode;

namespace dtt_testing
{
	/// <summary>
	/// pretends to be a set of input devices for test
	/// </summary>
	public class TestInput
	{
		public TestInput()
		{
			GameMessages.SetCallback<GameSession>(GameMessages.Kind.StartGame, OnStartGame);
		}

		private void OnStartGame(GameSession gs)
		{
			System.Diagnostics.Debug.WriteLine(gs.ToString());
		}
	}
}

