export interface MenuWithRole {
    id: number;
    path: string;
    title: string;
    icon: string;
    type: string;
    badgeType: string;
    badgeValue: string;
    active: boolean | null;
    sequent: number | null;
    bookmark: boolean | null;
    role_Id: string | null;
    role_Name: string;
    parent_Id: number | null;
}