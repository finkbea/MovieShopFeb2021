import {Cast} from './cast';
import {Genre} from './genre';

export interface MovieDetails {
    id: number;
    title: string;
    posterUrl: string;
    backdropurl: string;
    rating: number;
    overview: string;
    tagline: string;
    budget: number;
    revenue: number;
    imdblurl: string;
    tmdburl: string;
    releaseDate: Date;
    runTime: number;
    price: number,
    favoritesCount: number;
    casts: Cast[];
    genres: Genre[];
}