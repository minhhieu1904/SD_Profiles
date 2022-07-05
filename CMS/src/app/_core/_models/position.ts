export interface Position {
    id: number;
    name: string;
    description: string;
    status: boolean | null;
    create_By: string;
    create_Time: string | null;
    update_By: string;
    update_Time: string | null;
}