import { Author } from "./author";
import { Publisher } from "./publisher";

export class Book {
    reference: string;
    title: string;
    genre: string;
    price: number;
    codeAuthor: string;
    author: Author;
    codePublisher: string;
    publisher: Publisher;
}
