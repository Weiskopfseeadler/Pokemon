//====================================================================================================
//The Free Edition of Java to C# Converter limits conversion output to 100 lines per file.

//To purchase the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-java-to-csharp.html
//====================================================================================================

using System;
using System.Collections.Generic;

/// 
namespace ch.csbe.util
{

	using PhonemItem = ch.csbe.phonem.model.PhonemItem;

	/// <summary>
	/// @author rj
	/// 
	/// </summary>
	public class FileHandling
	{

		public FileHandling()
		{

		}

		/// <summary>
		/// Erstelt eine neue Datei für phonems
		/// </summary>
		/// <param name="fileName"> </param>
		public static void createDBFiles(string fileName)
		{
			string filePath = Constants.INDEX_PATH + fileName;

			File f = new File(filePath);
			if (!f.exists())
			{
				if (fileName.Equals(Constants.PHONEMS_INDEX))
				{
					Dictionary<string, PhonemItem> phonems = new Dictionary<string, PhonemItem>();
					writeDB(phonems);
				}
				else
				{
					Path file = Paths.get(filePath);

					try
					{
						Files.write(file, "".GetBytes());
					}
					catch (IOException e)
					{
						// TODO Auto-generated catch block
						Console.WriteLine(e.ToString());
						Console.Write(e.StackTrace);
					}
				}
			}
		}

		/// <summary>
		/// Fügt neue werte in die Index Datei
		/// </summary>
		/// <param name="filename"> </param>
		/// <param name="content"> </param>
		public static void updateDBFile(string filename, IList<string> content)
		{
			string filePath = Constants.INDEX_PATH + filename;

			File f = new File(filePath);
			string o = "";
			for (int i = 0; i < content.Count; i++)
			{
				o = o + content[i] + "\n";
			}

			Path file = Paths.get(filePath);

			try
			{
				Files.write(file, o.GetBytes());
			}
			catch (IOException e)
			{
				// TODO Auto-generated catch block
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
			}

		}
	/// <summary>
	/// Giebt alle Daten als  PonemItem Hash list aus
	/// @return
	/// </summary>
		public static Dictionary<string, PhonemItem> readDB()
		{
			Dictionary<string, PhonemItem> phonems = new Dictionary<string, PhonemItem>();

			System.IO.FileStream fi = null;
			ObjectInputStream oi = null;
			string path = Constants.INDEX_PATH + Constants.PHONEMS_INDEX;
			try
			{
				fi = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read);
				oi = new ObjectInputStream(fi);
				phonems = (Dictionary<string, PhonemItem>) oi.readObject();
			}
			catch (FileNotFoundException e)
			{
				// TODO Auto-generated catch block
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
			}
			catch (IOException e)
			{
				// TODO Auto-generated catch block
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
			}
			catch (ClassNotFoundException e)
			{
				// TODO Auto-generated catch block
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
			}
			finally
			{
				try
				{
					oi.close();
					fi.Close();
				}
				catch (IOException e)
				{
					// TODO Auto-generated catch block
					Console.WriteLine(e.ToString());
					Console.Write(e.StackTrace);
				}
			}

			return phonems;
		}

		/// <summary>
		/// Schreibt DB </summary>
		/// <param name="phonem"> </param>
		public static void writeDB(Dictionary<string, PhonemItem> phonem)
		{

			System.IO.FileStream fi = null;
			ObjectOutputStream oi = null;
			string path = Constants.INDEX_PATH + Constants.PHONEMS_INDEX;
			try
			{
				fi = new System.IO.FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write);
				oi = new ObjectOutputStream(fi);
				oi.writeObject(phonem);
			}
			catch (FileNotFoundException e)
			{
				// TODO Auto-generated catch block
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
			}
			catch (IOException e)
			{
				// TODO Auto-generated catch block
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
			}
			finally
			{
				try
				{
					oi.close();
					fi.Close();
				}
				catch (IOException e)
				{
					// TODO Auto-generated catch block
					Console.WriteLine(e.ToString());
					Console.Write(e.StackTrace);
				}
			}
		}
	/// <summary>
	/// Speichert alle Dateien alls File Obiekte
	/// @return
	/// </summary>
		public static File[] TextFiles
		{
			get
			{
				File folder = new File(Constants.TEXT_PATH);
				File[] listOfFiles = folder.listFiles();
    
				for (int i = 0; i < listOfFiles.Length; i++)
				{
					if (listOfFiles[i].File)
					{
					}
					else if (listOfFiles[i].Directory)
					{
						Console.WriteLine("ERROR " + listOfFiles[i].Name);
					}
				}
				return listOfFiles;
			}
		}

		/// <summary>
		/// giebt alle Verarbeiteten Files zurück
		/// @return
		/// </summary>
		public static IList<string> ProcessdFiles
		{
			get
			{
				IList<string> processed = new List<string>();
    
				System.IO.FileStream fstream;
				try
				{
					fstream = new System.IO.FileStream(Constants.INDEX_PATH + Constants.FILES_INDEX, System.IO.FileMode.Open, System.IO.FileAccess.Read);
    
					System.IO.StreamReader br = new System.IO.StreamReader(fstream);
    
					string strLine;
    
					// Read File Line By Line
    
					while (!string.ReferenceEquals((strLine = br.ReadLine()), null))
					{
						processed.Add(strLine);
					}
    
					// Close the input stream

//====================================================================================================
//End of the allowed output for the Free Edition of Java to C# Converter.

//To purchase the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-java-to-csharp.html
//====================================================================================================
