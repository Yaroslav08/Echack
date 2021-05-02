export class Currency {
    constructor(
        public id: number,
        public symbol: string,
        public code: string,
        public isoFormat: number,
        public name: string,
        public countries: string 
    ) { }
}