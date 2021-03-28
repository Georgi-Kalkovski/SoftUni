import page from '//unpkg.com/page/page.mjs';
import { html, render } from '//unpkg.com/lit-html?module';
import { until } from '//unpkg.com/lit-html/directives/until?module';
import { cache } from '//unpkg.com/lit-html/directives/cache?module';


const topics = {
    it: 'Information Technology',
    languages: 'Languages',
    hardware: 'Hardware',
    software: 'Software',
    frameworks: 'Frameworks'
};

export {
    page,
    html,
    render,
    until,
    topics,
    cache
};