using System;

namespace Math {

	public class EntryWheel : MachinePart {
		
		public enum ModelType { custom, ABC, QWERTY }
		
		public static String ABC = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		public static String QWERTY = "JWULCMNOHPQZYXIRADKEGVBTSF";
		
		public static EntryWheel CreateEntryWheelABC () {
			EntryWheel result = new EntryWheel (ABC);
			result.type = ModelType.ABC;
			result.Name = "ABC";
			return result;
		}
		
		public static EntryWheel CreateEntryWheelQWERTY () {
			EntryWheel result = new EntryWheel (QWERTY);
			result.type = ModelType.QWERTY;
			result.Name = "QWERTY";
			return result;
		}
		
		private ModelType type = ModelType.custom;
		
		public EntryWheel (int length) : base (length) { }
		
		public EntryWheel () : this (DEFAULT_LENGTH) { }
		
		public EntryWheel (int[] definition) : base (definition) { }
		
		public EntryWheel (string definition) : this (StringHelper.FromString(definition)) { }
		
		public ModelType Type {
			get { return type; }
		}

	}

}