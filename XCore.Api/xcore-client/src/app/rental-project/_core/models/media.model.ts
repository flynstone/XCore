export class Media {
    mediaId: number;
    itemTitle: string;
    categoryId: number;
    category: string;
}

export interface MediaForCreationDto {
    itemTitle: string;
    itemCategory: string;
}

export interface MediaForUpdateDto {
    itemTitle: string;
    itemCategory: string;
}
