import React, { Component } from 'react';
import './portfolio.css';
import { Title } from './Title';
import { Bio } from './Bio';
import { Skill } from './Skill';
import { Resume } from './Resume';
import { Project } from './Project';
import { Contact } from './Contact';

export class Portfolio extends Component {
    displayName = Portfolio.name;

    render() {
        return (
            <div className="portfolio-font">
                <Title />
                <Bio />
                <Skill />
                <Resume />
                <Project />
                <Contact />
            </div>
        );
    }
}