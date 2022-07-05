export interface Feature {
    id: number;
    title: string;
    description: string;
    image: string;
    status: boolean | null;
    create_By: string;
    create_Time: string | null;
    update_By: string;
    update_Time: string | null;
}