using System.Threading.Tasks;

namespace MvvmLightTry.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}