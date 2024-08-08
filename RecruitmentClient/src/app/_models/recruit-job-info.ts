import { RecruitInfo } from "./recruit-info";
import { WorkType } from "./work-type";

export interface RecruitJobInfo{
    recruitJobId: number;
    title: string;
    workPlace: string;
    recruit: RecruitInfo;
    recruitId: number;
    workType: WorkType;
}