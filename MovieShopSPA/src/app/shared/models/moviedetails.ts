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
    releasedate: Date;
    runtime: number;
    price: number,
    favoritescount: number;
    casts: Cast[];
    genres: Genre[];
}