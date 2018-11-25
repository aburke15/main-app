import React, { Component } from 'react';
import { Grid, Col, Row } from 'react-bootstrap';

export class Skill extends Component {

    render() {
        return (
            <section id="skills" className="skills-section global-padding">
                <Grid>
                    <Row>
                        <h2 className="text-center">Skills</h2>
                        <p className="b-underline"></p>
                    </Row>
                    <Row>
                        <Col md={6}>
                            <img className="skill-icon" src="../img/portfolio/c_sharp.png" alt="C# programming" />
                            <h3 className="text-center">C#</h3>
                        </Col>
                        <Col md={6}>
                            <img className="skill-icon" src="../img/portfolio/net_core.jpg" alt=".Net Core" />
                            <h3 className="text-center">.NET Core</h3>
                        </Col>
                    </Row>
                    <Row>
                        <Col md={6}>
                            <img className="skill-icon" src="../img/portfolio/sql_server.png" alt="SQL Server" />
                            <h3 className="text-center">MSSQL</h3>
                        </Col>
                        <Col md={6}>
                            <img className="skill-icon" src="../img/portfolio/ef_core.png" alt="EF Core" />
                            <h3 className="text-center">EF Core</h3>
                        </Col>
                    </Row>
                    <Row>
                        <Col md={6}>
                            <img className="skill-icon" src="../img/portfolio/css.png" alt="CSS3" />
                            <h3 className="text-center">CSS3</h3>
                        </Col>
                        <Col md={6}>
                            <img className="skill-icon" src="../img/portfolio/html_5.png" alt="HTML5" />
                            <h3 className="text-center">HTML5</h3>
                        </Col>
                    </Row>
                    <Row>
                        <Col md={6}>
                            <img className="skill-icon" src="../img/portfolio/javascript.jpg" alt="JavaScript" />
                            <h3 className="text-center">JavaScript</h3>
                        </Col>
                        <Col md={6}>
                            <img className="skill-icon" src="../img/portfolio/git.svg" alt="Git" />
                            <h3 className="text-center">Git</h3>
                        </Col>
                    </Row>
                </Grid>
            </section>
        );
    }
}