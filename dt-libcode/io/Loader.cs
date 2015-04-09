using System;
using System.Collections.Generic;

namespace dtlibcode
{
	public abstract class Loader
	{
		public event Func<Loader, bool> OnFinished;
		public event Func<Loader, bool> OnCanceled;

		/// <summary>
		/// Start the specified onDone.
		/// </summary>
		/// <param name="onDone">When finished, error or otherwise, use this callback.</param>
		public abstract void Start();

		/// <summary>
		/// Progress this loader.
		/// </summary>
		public abstract double Progress();

		/// <summary>
		/// Progress this loader.
		/// </summary>
		public abstract object Data { get; }

		/// <summary>
		/// Cancel the load
		/// </summary>
		/// <returns><c>true</c> if this instance cancel ; otherwise, <c>false</c>.</returns>
		public virtual bool Cancel()
		{
			if(OnCanceled != null)
			{
				OnCanceled.Invoke(this);
			}
			return true;
		}

		/// <summary>
		/// Raises the done event when the derived loader is complete.
		/// </summary>
		protected virtual bool DoDone()
		{
			if(OnFinished != null)
			{
				OnFinished.Invoke(this);
			}
			return true;
		}
	}
}

