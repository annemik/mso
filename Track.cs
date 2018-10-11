namespace Lab3
{
    public class Track
    {
        string startStation;
        string endStation;
        int tariefeenheid;

        public Track (string start, string end, int tarief)
        {
            startStation = start;
            endStation = end;
            tariefeenheid = tarief;
        }

        public void SwitchStations(string begin)
        {
            if (begin == endStation)
            {
                string swapStation = startStation;
                startStation = endStation;
                endStation = swapStation;

            }
        }

        public int GetTariefeenheden()
        {
            return tariefeenheid;
        }

        public string GetStationFrom()
        {
            return startStation;
        }

        public string GetStationTo()
        {
            return endStation;
        }
    }  
}
