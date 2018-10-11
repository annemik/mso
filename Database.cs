using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Lab3
{
	public class Database
	{
        public static int totaalTarief;
        public static List<Track> alleTracks = new List<Track>();

		public static String[] GetStations()
		{
            return new String[] {
                "Utrecht Centraal",
                "Gouda",
                "Geldermalsen",
                "Hilversum",
                "Duivendrecht",
                "Weesp"
            };
		}

        public static string[] alleStations = new[]
        {
                "Utrecht Centraal",     
                "Gouda",                
                "Geldermalsen",         
                "Hilversum",            
                "Duivendrecht",         
                "Weesp"                 
        };

        public static void AddTracks() 
        {
            // Utrecht Centraal
            alleTracks.Add(new Track(alleStations[0], alleStations[1], 32)); 
            alleTracks.Add(new Track(alleStations[0], alleStations[2], 26)); 
            alleTracks.Add(new Track(alleStations[0], alleStations[3], 18)); 
            alleTracks.Add(new Track(alleStations[0], alleStations[4], 31)); 
            alleTracks.Add(new Track(alleStations[0], alleStations[5], 33)); 

            // Gouda
            alleTracks.Add(new Track(alleStations[1], alleStations[2], 58)); 
            alleTracks.Add(new Track(alleStations[1], alleStations[3], 50)); 
            alleTracks.Add(new Track(alleStations[1], alleStations[4], 54));
            alleTracks.Add(new Track(alleStations[1], alleStations[2], 57)); 

            // Geldermalsen
            alleTracks.Add(new Track(alleStations[2], alleStations[3], 44)); 
            alleTracks.Add(new Track(alleStations[2], alleStations[4], 57)); 
            alleTracks.Add(new Track(alleStations[2], alleStations[5], 59)); 

            // Hilversum
            alleTracks.Add(new Track(alleStations[3], alleStations[4], 18)); 
            alleTracks.Add(new Track(alleStations[3], alleStations[5], 15)); 

            // Duivendrecht
            alleTracks.Add(new Track(alleStations[4], alleStations[5], 3)); 
        }

        public static int GetTariefeenheden(List<Track> Tracks, string beginStation, string endStation)
        {
            if (beginStation == endStation)
            {
                MessageBox.Show("You have selected the same start station and destination.");
                return 0;
            }

            foreach (Track station in Tracks)
            {
                if (station.GetStationFrom() == beginStation || station.GetStationTo() == beginStation)
                {
                    station.SwitchStations(beginStation);

                    if (station.GetStationTo() == endStation)
                    {
                        totaalTarief = station.GetTariefeenheden();
                        return totaalTarief;
                    }
                }
            }
            return 0;
        }
    }
}