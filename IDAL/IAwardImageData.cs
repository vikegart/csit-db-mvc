using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IAwardImageData
    {
        Image GetImageByAward(int idAward);

        void AddAwardImage(Image image);

        void DeleteAwardImage(int idAward);

        void Update(int idAward, Image newImage);
    }
}
