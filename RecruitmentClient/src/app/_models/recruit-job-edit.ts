import { Recruit } from "./recruit";

export class RecruitJobEdit{
    recruitJobId: number;
    title: string;
    workPlace: string;
    recruit: Recruit;
    recruitId: number;
    position: string;
    amount: number;
    professionId: number;
    salaryId: number;
    levelInfoId: number;
    workTypeId: number;
    experienceId: number;
    gender: number;
    expirationDate: Date;
    describe: string = "";
    require: string = "";
    benefit: string = "";
    //Thong tin lien he
    emailContact: string;
    phoneContact: string;
    nameContact: string;
    //Dia chi
    cityId: number;
    districtId: number;
    wardId: number;
    

}