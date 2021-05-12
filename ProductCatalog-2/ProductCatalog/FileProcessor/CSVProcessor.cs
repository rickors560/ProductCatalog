using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileProcess
{
    public class CSVProcessor : FileProcessor 
    {
        public CSVProcessor(string filePath) : base(filePath){

        }

        public List<string[]> GetAllRecords() {
            var data =  base.GetAllData()
                .Select(d => 
                    d.Split(new char[] { ',' }).ToList()
                    .Select(d => d.Trim()).ToArray())
                .ToList();
            return data;
        }
        public void AppendRecord(string[] record) {
            record = record.Select(x => x.Trim()).ToArray(); //trimming all spaces
            string data = String.Join(" ,", record);
            base.AppendData(data);
        }

        public void OverWriteRecords(List<string[]> records) {
            var data = new List<string>();
            records.ForEach(record => {
                data.Add(String.Join(",", (record.Select(x => x.Trim()).ToArray())));
            });
            base.OverwriteAll(data);
        }
    }
}