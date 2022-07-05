export interface Faq {
    id: number;
    title: string;
    description: string;
    content: string;
    status: boolean | null;
    create_By: string;
    create_Time: string | null;
    update_By: string;
    update_Time: string | null;
}