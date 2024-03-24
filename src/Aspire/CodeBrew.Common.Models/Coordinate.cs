namespace CodeBrew.Common.Models;

public class Coordinate
{
    #region Public Constructors

    public Coordinate()
    {
    }

    public Coordinate(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    #endregion Public Constructors

    #region Public Properties

    // Create a coordinate class that has latitude and longitude
    public double Latitude { get; set; }

    public double Longitude { get; set; }

    #endregion Public Properties

    #region Public Methods

    public override string ToString()
    {
        return $"Latitude: {Latitude}, Longitude: {Longitude}";
    }

    #endregion Public Methods

}