using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CCPhotoUpload
{
    public partial class SearchPhoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var keyword = txtSearch.Text;
            var DC = new DataClassesDataContext();
            var SearchedImages = (from ob in DC.tblFiles
                                  join obK in DC.tblKeywords on ob.ImageID equals obK.ImageID
                                  where SqlMethods.Like(obK.Keyword, keyword)
                                  select new
                                  {
                                      ob.ImageID,
                                      ob.Title,
                                      ob.Filepath,
                                      ob.Description,
                                      ob.Size,
                                      ob.Type,
                                      Keywords = (from obKws in DC.tblKeywords
                                                  where ob.ImageID == obKws.ImageID
                                                  select obKws)
                                  });
            rptImages.DataSource = SearchedImages;
            rptImages.DataBind();
        }
    }
}