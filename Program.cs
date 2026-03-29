using System.Xml.Linq;

namespace HealthCareSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // System Storage
            
            string[] patientNames = new string[100];
            string[] patientIDs = new string[100];
            string[] diagnoses = new string[100];
            bool[] admitted = new bool[100];       // true = currently admitted
            string[] assignedDoctors = new string[100];
            string[] departments = new string[100];     // e.g. "Cardiology", "Orthopedics"
            int[] visitCount = new int[100];        // how many times admitted
            double[] billingAmount = new double[100];     // total fees owed
            int lastPatientIndex = 0;

            //seed data 

            //Patient 1:

            patientNames[lastPatientIndex] = "Ali Hassan";
            patientIDs[lastPatientIndex]= "P001";
            diagnoses[lastPatientIndex] = "Flu";
            departments[lastPatientIndex]= "General";
            admitted[lastPatientIndex]= false;
            assignedDoctors[lastPatientIndex]= "";
            visitCount[lastPatientIndex]= 2;
            billingAmount[lastPatientIndex]= 0;

            lastPatientIndex++;

            //Patient 2:

            patientNames[lastPatientIndex] = "Sara Ahmed";
            patientIDs[lastPatientIndex] = "P002";
            diagnoses[lastPatientIndex] = "Fracture";
            departments[lastPatientIndex] = "Orthopedics";
            admitted[lastPatientIndex] = true;
            assignedDoctors[lastPatientIndex] = "Dr. Noor";
            visitCount[lastPatientIndex] = 4;
            billingAmount[lastPatientIndex] = 0;

            lastPatientIndex++;


            //Patient 3:

            patientNames[lastPatientIndex] = "Omar Khalid";
            patientIDs[lastPatientIndex] = "P003";
            diagnoses[lastPatientIndex] = "Diabetes";
            departments[lastPatientIndex] = "Cardiology";
            admitted[lastPatientIndex] = false;
            assignedDoctors[lastPatientIndex] = "";
            visitCount[lastPatientIndex] = 1;
            billingAmount[lastPatientIndex] = 0;

            lastPatientIndex++;



        }
    }
}
