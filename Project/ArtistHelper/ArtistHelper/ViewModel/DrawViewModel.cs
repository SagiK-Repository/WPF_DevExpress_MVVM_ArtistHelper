using ArtistHelper.Model;

namespace ArtistHelper.ViewModel
{
    public class DrawViewModel
    {
        #region 변수
        #endregion

        #region 프로퍼티
        public ArtistModel<double> ArtistModels { get; set; }
        #endregion

        #region 생성자
        public DrawViewModel(ArtistModel<double> artistModel)
        {
            ArtistModels = artistModel;
        }
        #endregion

        #region 메소드
        public void Update()
        {

        }
        #endregion
    }
}
