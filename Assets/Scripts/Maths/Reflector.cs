using System;

namespace Math {
	
	public class Reflector : MachinePart {

		public enum ModelType { custom, B, C }

		public static String B = "YRUHQSLDPXNGOKMIEBFZCWVJAT";
		public static String C = "FVPJIAOYEDRZXWGCTKUQSBNMHL";
		
		public static Reflector CreateReflectorB () {
			Reflector result = new Reflector (B);
			result.type = ModelType.B;
			result.Name = "B";
			return result;
		}
		
		public static Reflector CreateReflectorC () {
			Reflector result = new Reflector (C);
			result.type = ModelType.C;
			result.Name = "C";
			return result;
		}

		private ModelType type = ModelType.custom;
		
		public Reflector (int length) : base (length) {
			// TODO sprawdzić, czy długość parzysta (jak nie - wyjątek) i ustawić połączenia sąsiednich par, tzn (0,1)(2,3)...
		}
		
		public Reflector () : this (DEFAULT_LENGTH) { }
		
		public Reflector (int[] definition) : base (definition) {
			// TODO sprawdzić, czy definicja jest poprawną inwolucją bez punktów stałych i jeśli nie - rzucić wyjątkiem
		}
		
		public Reflector (string definition) : this (StringHelper.FromString(definition)) { }

		public ModelType Type {
			get { return type; }
		}
		
	}

}