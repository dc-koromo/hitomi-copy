/*************************************************************************

   Copyright (C) 2018. dc-koromo. All Rights Reserved.

   Author: Koromo Hitomi Copy Developer

***************************************************************************/

using System.Collections.Generic;

namespace Hitomi_Copy_4.Interface
{
    /// <summary>
    /// 한 작품을 나타내는 단위입니다.
    /// </summary>
    public interface IArticle
    {
        string Thumbnail { get; set; }
        string Title { get; set; }
        List<string> ImagesLink { get; set; }
    }
}
