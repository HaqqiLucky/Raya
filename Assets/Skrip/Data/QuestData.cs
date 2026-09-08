using System;
using System.Collections.Generic;
using UnityEngine;


public enum NPCidTranlate
{
    Anisa = 01000001,
    Ranto = 102,
    Indah = 103,
    Raka = 104,
    Jainah = 105,
    Nia = 106,
    Haqi =  01001000,
    Liam = 01001100,
    Sakinah = 01010011,
    Raya = 01010010


}
[Serializable]
public class QuestVariable
{
    public int idQuestData;
    public NPCidTranlate idNPC;
    public string objektif;
    public string namaAct;

    // buat constructor
    public QuestVariable(int idQD, NPCidTranlate idNP, string obj, string act)
    {
        idQuestData = idQD;
        idNPC = idNP;
        objektif = obj;
        namaAct = act;

    }
}

public class QuestData
{
    public List<QuestVariable> daftarQuest = new List<QuestVariable>()
    {
        // act 1
        new QuestVariable(1, NPCidTranlate.Anisa, "Bicara pada nona berbaju hijau", "Act_1_2"),
        new QuestVariable(2, NPCidTranlate.Ranto, "Cari orang dengan nama pak ranto", "Act_1_3"),
        new QuestVariable(3, NPCidTranlate.Ranto, "Cari ketiga kucing di sekitar", "Act_1_4"), // butuh variabel int kucing yang di ambil 1/3
        new QuestVariable(4, NPCidTranlate.Indah, "Cari orang dengan nama Indah", "Act_1_5"),
        new QuestVariable(5, NPCidTranlate.Indah, "Ambil air dari sumur sebelah barat desa", "Act_1_6"), // butuh variabel int ember 1/5



        // act 2
        new QuestVariable(6, NPCidTranlate.Anisa, "Kembali ke anisa dan istirahat di pusat", "Act2_0"),
        new QuestVariable(7, NPCidTranlate.Raya, "Buka surat", "Act2_1"), //ini harusnya surat
        new QuestVariable(6, NPCidTranlate.Anisa, "Kembali ke anisa dan istirahat di pusat", "Act2_0"),


        // act3
        new QuestVariable(6, NPCidTranlate.Anisa, "Ambil tugas dari anisa", "Act3_0"),
        new QuestVariable(6, NPCidTranlate.Jainah, "Cari orang dengan nama Jainah", "Act3_1"),
        new QuestVariable(6, NPCidTranlate.Raka, "Cari orang dengan nama Raka", "Act3_2"),
        new QuestVariable(6, NPCidTranlate.Raka, "Ikuti Pak Raka", "Act3_3"), // 1/4 jalan
        new QuestVariable(6, NPCidTranlate.Raka, "Ikuti Pak Raka", "Act3_4"), // 2/4 jalan
        new QuestVariable(6, NPCidTranlate.Raka, "Ikuti Pak Raka", "Act3_5"), // 3/4 jalan

        // act4 
        new QuestVariable(6, NPCidTranlate.Raya, "....", "Act4_0"),
        new QuestVariable(6, NPCidTranlate.Anisa, "Balik ke pusat dan bicara kepada anisa", "Act4_1"),
        new QuestVariable(6, NPCidTranlate.Raya, "Baca surat", "Act4_2"),
        new QuestVariable(6, NPCidTranlate.Anisa, "Tanyakan perihal surat kepada anisa", "Act4_3"),
        new QuestVariable(6, NPCidTranlate.Raya, "....", "Act4_0"),
    };
}
