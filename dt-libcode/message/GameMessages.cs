using System;

namespace dtlibcode
{
	static public class GameMessages
	{
		public enum Kind
		{
			Error,
			PlayerLogin,
			PlayerLogout,
			WorldLoaded,
			StartGame,
			ThingAdded,
			ThingRemoved,
			SetOptionsFor
		}
		
		static public void SetCallback(Kind kind, Callback cb)
		{
			Messenger.AddListener(kind.ToString(), cb);
		}

		static public void SetCallback<T>(Kind kind, Callback<T> cb)
		{
			Messenger.AddListener(kind.ToString(), cb);
		}

		static public void SetCallback<T, U>(Kind kind, Callback<T,U> cb)
		{
			Messenger.AddListener(kind.ToString(), cb);
		}

		static public void SetCallback<T, U, V>(Kind kind, Callback<T,U,V> cb)
		{
			Messenger.AddListener(kind.ToString(), cb);
		}
	}
}

