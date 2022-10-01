using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MedicineCreator
{
    public static Medicine CreateMedicine(string newID, string medicineName, string newPatientData) //don't really need to ID a patients specific medicineSO's
    {
        //Medicine med = SO_Creator<Medicine>.CreateT(medicineName, $"{PatientCreator.patientID}/Medicines/");
        Medicine med = new Medicine();

        med.Init(medicineName, newPatientData);
        return med;
    }
    //public static Medicine CreateMedicine(Medicine medicineTemplate) //don't really need to ID a patients specific medicineSO's
    //{
    //    Medicine med = SO_Creator<Medicine>.CreateT(medicineTemplate.ID(), $"{PatientCreator.patientID}/Medicines/");

    //    med.Init(medicineID, newPatientData);
    //    return med;
    //}

}
