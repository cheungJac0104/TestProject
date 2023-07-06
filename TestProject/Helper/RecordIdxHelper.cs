using TestProject.Context;

namespace TestProject.Helper
{
    public static class RecordIdxHelper
    {
 

        public static string GetNextId(AppDBContext db, string tableName)
        {
          try {
            var _sRecordIdx = db.SRecordIdx.Where(x => x.TABLENAME == tableName).OrderByDescending(p => p.RECORD_IDX).FirstOrDefault();
            _sRecordIdx.INDEX_LAST_ID = _sRecordIdx.INDEX_LAST_ID + 1;
            string _nextRecordIdx = $"{_sRecordIdx.INDEX_PREFIX}{ (_sRecordIdx.INDEX_LAST_ID).ToString().PadLeft(_sRecordIdx.INDEX_LENGHT - _sRecordIdx.INDEX_PREFIX.Length, '0') }";   //ID0000013028

            //Update S_RECORD_IDX
            db.SRecordIdx.Update(_sRecordIdx);
            db.SaveChanges();
            return _nextRecordIdx;
          } catch (Exception ex) {
            System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
            throw;
          }

        }

    }
}
