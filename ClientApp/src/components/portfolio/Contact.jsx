import React, { Component } from 'react';
import { Glyphicon, Grid, Row } from 'react-bootstrap';

export class Contact extends Component {

    render() {
        return (
            <section id="contact" className="contact-section global-padding">
                <Grid>
                    <Row className="contact-margin contact-top-row">
                        <h4 className="text-center">
                            <a className="contact-email" href="mailto:aburkex24@gmail.com" rel="noopener" target="_top">
                                <Glyphicon glyph="envelope" /> aburkex24@gmail.com
                            </a>
                        </h4>
                        <h4 className="text-center contact-phone">
                            <Glyphicon glyph="phone" /> 801-708-2782
                        </h4>
                    </Row>
                    <Row>
                        <div className="text-center">
                            <a className="contact-icon-space" href="https://www.linkedin.com/in/aburkex24" rel="noopener" target="_blank">
                                <img className="contact-icon" src="../img/portfolio/linkedin.png" />
                            </a>
                            <a className="contact-icon-space" href="https://www.youtube.com/channel/UCczcmJfcsvhmW-65r1RuZ4w/featured?view_as=subscriber" rel="noopener" target="_blank">
                                <img className="contact-icon" src="../img/portfolio/youtube.png" />
                            </a>
                            <a className="contact-icon-space" href="https://github.com/aburkex24" rel="noopener" target="_blank">
                                <img className="contact-icon" src="../img/portfolio/github.png" />
                            </a>
                        </div>
                    </Row>
                </Grid>
            </section>
        );
    }
}