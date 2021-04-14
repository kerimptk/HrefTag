using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using System.Collections.Generic;

namespace Blog.Domain.Interfaces
{
    public interface IPostaKutusuService
    {
        List<PostaKutusu> GetList();
        IDataResult<PostaKutusu> Add(PostaKutusu entity);
        IDataResult<PostaKutusu> Update(PostaKutusu entity);
        IResult Delete(PostaKutusu entity);
        IResult DeleteList(List<PostaKutusu> entities);
        PostaKutusu GetById(int id);
        List<PostaKutusu> GetOkunmamisList();
        List<PostaKutusu> GetSilinmisList();
        List<PostaKutusu> GetOneriIstekList();
        List<PostaKutusu> GetHataBildirimiList();
        List<PostaKutusu> GetReklamVeIsBirligiList();
        List<PostaKutusu> GetDigerList();

    }
}
