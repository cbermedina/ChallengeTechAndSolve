namespace ChallengeTechAndSolve.Business
{
    using ChallengeTechAndSolve.Business.Models;
    using ChallengeTechAndSolve.Common.Enum;
    using ChallengeTechAndSolve.Common.Helpers;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class ProcessFile
    {
       
        /// <summary>
        /// Read file from IFormFile to List<int>
        /// </summary>
        /// <param name="file"></param>
        /// <param name="lstInformationFile"></param>
        /// <returns></returns>
        public async Task ReadAsStringAsync(IFormFile file, List<int> lstInformationFile)
        {
            using StreamReader reader = new StreamReader(file.OpenReadStream());
            string fileLine = string.Empty;
            int day = 1;
            while (reader.Peek() >= 0)
            {
                fileLine = await reader.ReadLineAsync();
                if (!string.IsNullOrEmpty(fileLine) && Validations.IsNaturalNumber(fileLine))
                {
                    lstInformationFile.Add(Convert.ToInt32(fileLine));
                    day++;
                }
                fileLine = string.Empty;
            }
        }
        /// <summary>
        /// Process file
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        public async Task<MemoryStream> FileProcess(ParticipantInformationDto participantInformationDto)
        {
            List<int> lstInformationFile = new List<int>();
            await ReadAsStringAsync(participantInformationDto.FileInfo, lstInformationFile);
            List<string> lstResult = new List<string>();
            ValidateInformation(lstInformationFile, lstResult);
            StringBuilder strResultBuilder = new StringBuilder();
            lstResult.ForEach(item => strResultBuilder.AppendLine(item));
            return new MemoryStream(Encoding.UTF8.GetBytes(strResultBuilder?.ToString()));

        }
        /// <summary>
        /// Validate general information
        /// </summary>
        /// <param name="lstInformationFile">List information extracted from file</param>
        /// <param name="lstResult">Validation result</param>
        private void ValidateInformation(List<int> lstInformationFile, List<string> lstResult)
        {
            int numberDay = 0;
            int countDetail;
            if (lstInformationFile.Any() && lstInformationFile.First() <= (int)Restrictions.FiveHundred)
            {
                for (int count = 1; count < lstInformationFile.Count; count++)
                {
                    numberDay++;
                    var countElements = lstInformationFile[count];

                    if (countElements <= (int)Restrictions.OneHundred)
                    {
                        List<int> sizeElement = new List<int>();

                        for (countDetail = count + 1; countDetail <= (count + countElements); countDetail++)
                        {
                            if (lstInformationFile[countDetail] <= (int)Restrictions.OneHundred)
                                sizeElement.Add(lstInformationFile[countDetail]);
                        }
                        lstResult.Add(string.Format("Case # {0} : {1}", numberDay, GetNumberTrips(sizeElement)));
                        count = countDetail - 1;
                    }
                }
            }
        }
        /// <summary>
        /// Get number of trips
        /// </summary>
        /// <param name="lstValues"></param>
        /// <returns></returns>
        public int GetNumberTrips(List<int> lstValues)
        {
            var itemMax = lstValues.Max();
            lstValues.Remove(itemMax);
            int size = (int)Restrictions.Zero, numberOfTrips= (int)Restrictions.Zero;
            var counter = (int)Restrictions.One;
            while (size < (int)Restrictions.Fifty)
            {
                if (lstValues.Count == (int)Restrictions.Zero)
                    return 0;
                var itemMin = lstValues.Min();
                lstValues.Remove(itemMin);
                counter++;
                size = itemMax * counter;
            }
            numberOfTrips++;
            if (lstValues.Count > 0)
                numberOfTrips += GetNumberTrips(lstValues);
            return numberOfTrips;
        }

    }
}
