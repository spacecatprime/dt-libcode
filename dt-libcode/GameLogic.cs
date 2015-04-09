using System;
using System.Collections.Generic;

/// <summary>
/// TODO: break out each class to their own modules after the design
/// </summary>
namespace dtlibcode
{
	/// <summary>
	/// Contains the game logic for a type of game
	/// </summary>
//	public class GameModule
//	{
//		public string Name { get; set; }
//		public string Description { get; set; }
//		public MovementLogic MovementLogic { get; set; }
//	}

	/// <summary>
	/// the general type of game for the logic
	/// </summary>
//	public struct MoveParameters
//	{
//		// how the figures can be selected (TODO: should be flags?)
//		public enum SelectionType
//		{
//			Unit,
//			Formation,
//			Loose
//		}
//		public SelectionType Selection { get; set; }
//
//		// legal ways the figures can be moved
//		public enum MovementFlags
//		{
//			Strafe		= 1 << 0,
//			Straight	= 1 << 1,
//			Back		= 1 << 2,
//			Turn		= 1 << 3
//		}
//		public MovementFlags MovementFlagSet { get; set; }
//
//		// how actions can be sent to the selection
//		public enum ActionFlags
//		{
//			ToEachUnit	= 1 << 0,
//			ToLeader	= 1 << 1,
//			ToFormation	= 1 << 2
//		}
//		public ActionFlags ActionFlagSet { get; set; }
//	}

	/// <summary>
	/// Movement logic. Custom to each game, but there should be some general examples.
	/// </summary>
//	public abstract class MovementLogic
//	{
//		public MoveParameters MoveParameters { get; set; }
//	}

	/// <summary>
	/// One of the game players. 
	/// Could be a player from a certain team, an observer, or even a "game master" if the game needs one
	/// </summary>
//	public interface GamePlayer
//	{
//	}

	/// <summary>
	/// One figure unit on the map. This is more of the game logic container rather than the visual parameters, 
	/// though some of these stats will likely change the visuals for the figure such as a team color.
	/// </summary>
//	public interface FigureUnit
//	{
//		bool Select(GamePlayer selector);
//		bool Deselect(GamePlayer selector);
//	}

	/// <summary>
	/// A groups for a set of figures such as a squad, regiment, or brigade
	/// </summary>
//	public abstract class FigureGroup
//	{
//		List<FigureUnit> UnitList { get; set; }
//		bool Select(GamePlayer selector);
//		bool Deselect(GamePlayer selector);
//	}

}

