export class Category {
    categoryId: number;
    description: string;
}

export interface CategoryForCreationDto {
    description: string;
}

export interface CategoryForUpdateDto {
    description: string;
}