using System.Collections.Generic;

namespace App.Extractors
{
    public interface IExtractor
    {
        ICollection<double> ExtractValues(string json);
    }
}
