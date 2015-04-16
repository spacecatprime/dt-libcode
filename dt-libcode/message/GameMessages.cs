using System;

namespace dtlibcode
{
	static public class GameMessages
	{
		public enum Kind
		{
			Error,

			AssignHost,

			PlayerLogin,
			PlayerLogout,

			SetOptionsFor,

			WorldLoaded,

			GameBegin,
			GameObjectivesComplete,
			GameEnd,

			ThingAdded,
			ThingRemoved,

			RoundBegin,
			RoundEnd,

			TurnBegin,
			TurnStep,
			TurnEnd
		}

		static public void Emit(Kind kind)
		{
			Messenger.Emit(kind.ToString());
		}

		static public void Emit<T>(Kind kind, T t)
		{
			Messenger.Emit<T>(kind.ToString(), t);
		}

		static public void Emit<T, U>(Kind kind, T t, U u)
		{
			Messenger.Emit<T, U>(kind.ToString(), t, u);
		}

		static public void Emit<T, U, V>(Kind kind, T t, U u, V v)
		{
			Messenger.Emit<T, U, V>(kind.ToString(), t, u, v);
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

