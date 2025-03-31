using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadyBoardGame_Shop
{
    static public class AddressUtil
    {
        static public void ReadAddressInfoFromCSVFile(string strAddressCSVFile,
                                                      ref string[] arProvinces,
                                                      ref string[][] arDistricts,
                                                      ref string[][][] arSubDistricts,
                                                      ref string[][][] arPostcodes)
        {   
            if (File.Exists(strAddressCSVFile))
            {
                string[] arDataAddress = File.ReadAllLines(strAddressCSVFile, Encoding.GetEncoding("utf-8"));
                const int POSTCODE = 3;
                const int PROVINCE = 2;
                const int DISTRICT = 1;
                const int SUBDIST = 0;

                int nRowCount = arDataAddress.Length;

                List<string> listProvinces = new List<string>();
                List<string> listDistricts = new List<string>();
                List<string> listSubDistricts = new List<string>();
                List<string> listPostcodes = new List<string>();
                List<string[]> listAllDistricts = new List<string[]>();
                List<string[]> listAllSubDistricts = new List<string[]>();
                List<string[]> listAllPostcode = new List<string[]>();
                string[] arAddress = null;


                int nCurRow = 1;
                if (nCurRow < nRowCount)
                {
                    arAddress = arDataAddress[nCurRow].Split(',');
                }
                while (nCurRow < nRowCount)
                {
                    string curPostcode = arAddress[POSTCODE];
                    string curDistrict = arAddress[DISTRICT];
                    string curProvince = arAddress[PROVINCE];
                    string curSubDistrict = arAddress[SUBDIST];
                    listPostcodes.Add(curPostcode);
                    listProvinces.Add(curProvince);
                    listSubDistricts.Add(curSubDistrict);
                    if (nCurRow < nRowCount)
                    {
                        arAddress = arDataAddress[nCurRow].Split(',');
                    }
                    while (nCurRow < nRowCount && curProvince == arAddress[PROVINCE])
                    {
                        curPostcode = arAddress[POSTCODE];
                        curDistrict = arAddress[DISTRICT];
                        curProvince = arAddress[PROVINCE];
                        curSubDistrict = arAddress[SUBDIST];
                        listPostcodes.Add(curPostcode);
                        listDistricts.Add(curDistrict);
                        listSubDistricts.Add(curSubDistrict);
                        nCurRow++;
                        if (nCurRow < nRowCount)
                        {
                            arAddress = arDataAddress[nCurRow].Split(',');

                        }
                        while (nCurRow < nRowCount && curDistrict == arAddress[DISTRICT])
                        {
                            curPostcode = arAddress[POSTCODE];
                            curProvince = arAddress[PROVINCE];
                            curDistrict = arAddress[DISTRICT];
                            curSubDistrict = arAddress[SUBDIST];
                            listPostcodes.Add(curPostcode);
                            listSubDistricts.Add(curSubDistrict);
                            nCurRow++;
                            if (nCurRow < nRowCount)
                            {
                                arAddress = arDataAddress[nCurRow].Split(',');
                            }
                        }
                        listAllPostcode.Add(listPostcodes.ToArray());
                        listAllSubDistricts.Add(listSubDistricts.ToArray());
                        listPostcodes.Clear();
                        listSubDistricts.Clear();
                    }
                    listAllDistricts.Add(listDistricts.ToArray());
                    listDistricts.Clear();

                }
                arProvinces = listProvinces.ToArray();
                arDistricts = new string[arProvinces.Length][];
                arSubDistricts = new string[arProvinces.Length][][];
                arPostcodes = new string[arProvinces.Length][][];
                int dt = 0;
                for (nCurRow = 0; nCurRow < arProvinces.Length; nCurRow++)
                {
                    int nDistrictsLength = listAllDistricts[nCurRow].Length;
                    arSubDistricts[nCurRow] = new string[nDistrictsLength][];
                    arPostcodes[nCurRow] = new string[nDistrictsLength][];
                    for (int j = 0; j < nDistrictsLength; j++, dt++)
                    {
                        arSubDistricts[nCurRow][j] = listAllSubDistricts[dt].ToArray();
                        arPostcodes[nCurRow][j] = listAllPostcode[dt].ToArray();

                    }
                    arDistricts[nCurRow] = listAllDistricts[nCurRow].ToArray();
                }
            }
            else
            {
                Console.WriteLine("File not found!");
            }
        }
    }
}
