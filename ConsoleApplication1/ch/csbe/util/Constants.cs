/// 
namespace ch.csbe.util
{
	/// <summary>
	/// @author vmuser
	/// 
	///         avoid hard coded Constants in source code, instead use Constants from
	///         this class
	/// 
	/// </summary>
	public class Constants
	{
		// Datenstruktur

		public const string TEXT_PATH = "/home/vmuser/mytexts/";
		public const string INDEX_PATH = "/home/vmuser/myIndex/";

		public const string FILES_INDEX = "processedFiles.dat";
		public const string PHONEMS_INDEX = "phonemDatabase.dat";

		public static readonly char[] ALPHA = new char[] {'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z'};
		public const string ALPHA_STRING = "BCDFGHJKLMNPQRSTVWXYZ";

	}

}