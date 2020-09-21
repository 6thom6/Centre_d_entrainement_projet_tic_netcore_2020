/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

insert into [dbo].[Entrainement] ([dbo].[Entrainement].[Cheval],
                                  [dbo].[Entrainement].[Plat],
                                  [dbo].[Entrainement].[Obstacle],
                                  [dbo].[Entrainement].[Marcheur],
                                  [dbo].[Entrainement].[Duree],
                                  [dbo].[Entrainement].[Pre],
                                  [dbo].[Entrainement].Id_Employe)
values 
('dala','1000m','2tours','none','2h','none','1'),
('khani','1500m','3tours','none','2h','none','2'),
('zarkandar','2000m','6tours','none','2h30','none','3'),
('dubawi','3500m','2tours','none','2h','none','4'),
('alpha spirit','3000m','none','2h','1h','none','5')

insert into [dbo].[Course] ([dbo].[Couse].[Hippodrome],
                            [dbo].[Couse].[Date_Courses],
                            [dbo].[Couse].[Distance],
                            [dbo].[Couse].[Corde],
                            [dbo].[Couse].[Discipline],
                            [dbo].[Couse].[Terrain],
                            [dbo].[Couse].[Avis],
                            [dbo].[Couse].[Jockey],
                            [dbo].[Couse].[Poids_De_Course])
Values 
('Auteuil','2020-09-01','4600','8','steeple','lourd','pas degueux','gueguen','68.5'),
('Auteuil','2020-09-02','3600','gauche','haie','tres lourd','bien','obrian','68.5'),
('Dieppe','2020-10-03','3800','droite','steeple','bon','bof','zuliani','68.5'),
('Longchamps','2020-09-04','1600','droite','plat','léger','passable','lestrade','68.5'),
('Compiegne','2020-09-05','3900','gauche','steeple','lourd','degueux','masure','68.0')

insert into [dbo].[Employe] ([dbo].[Employe].[Nom_Employe],
                             [dbo].[Employe].[Date_Embauche],
                             [dbo].[Employe].[Statuts_Employe])
values
('zuliani','2020-10-01','jockey'),
('Lemagnen','2020-10-02','apprenti'),
('Nabet','2020-10-03','garcon_decurie'),
('Lestrade','2020-10-04','garcon_de_voyage'),
('Gallon','2020-10-05','jockey')


insert [dbo].[Vaccination]([dbo].[Vaccination].[Nom_vaccin],
                           [dbo].[Vaccination].[Delai_Indisponibilite])
values
('polyo','2020-10-10'),
('polyo','2020-10-12'),
('polyo','2020-10-13'),
('polyo','2020-10-14'),
('polyo','2020-10-15')




--SET IDENTITY_INSERT [Proprietaire] ON
insert [dbo].[Proprietaire]([dbo].[Proprietaire].[Nom_Proprietaire],
                            [dbo].[Proprietaire].[Date_Arrivee],
                            [dbo].[Proprietaire].[Dernier_Resultat])
values
('nicole','2020-12-05','1er'),
('papot','2020-06-03','1er'),
('schule','2020-08-04','2eme'),
('Delay','2020-07-05','np'),
('deWaele','2020-10-15','np')



INSERT INTO [dbo].[Cheval] ([dbo].[Cheval].[Nom_cheval],
                            [dbo].[Cheval].[Pere_cheval],
                            [dbo].[Cheval].[Mere_cheval],
                            [dbo].[Cheval].[Sortie_provisoire],
                            [dbo].[Cheval].[Raison_Sortie],
                            [dbo].[Cheval].[Id_Proprietaire],
                            [dbo].[Cheval].[Id_Soins],
                            [dbo].[Cheval].[Poids],
                            [dbo].[Cheval].[Race],
                            [dbo].[Cheval].[Age],
                            Sexe)
                            
                            
VALUES  
('dala','dalakhani','zarkava','2020-07-02','repos','1','1','450','PS','4','M'),
('khani','dalakhani','zarkava','2020-07-12','repos','2','2','450','PS','5','F'),
('zarkandar','dalakhani','zarkava','2020-11-02','repos','3','3','450','PS','3','H'),
('dubawi','dalakhani','zarkava','2020-05-02','repos','1','4','450','PS','6','E'),
('alpha spirit','zarak','zarkava','2020-09-24','repos','3','5','450','PS','4','F');

insert [dbo].[Soins]([dbo].[Soins].[Id_Cheval],
                     [dbo].[Soins].[Id_Employe],
                     [dbo].[Soins].[Vermifuge],
                     [dbo].[Soins].[Marechal_derniere_visite],
                     [dbo].[Soins].[Note_Libre],
                     date_de_soin,
                     Type_de_soin,
                     durree_indisponibilite,
                     Alimentation,
                     Complement_Alimentation)
values
('1','4','2020-01-25','2020-09-10','complet','2020-09-10','infiltration_ant_d','7j','2litres','rien'),
('1','2','2020-04-07','2020-08-11','complet','2020-08-11','fracture_ant_g','15mois','2litres','foin'),
('2','2','2020-03-25','2020-07-15','complet','2020-07-15','tendinite_pos_d','1mois','2litres','granullé'),
('4','4','2020-01-15','2020-06-04','complet','2020-06-04','infiltration_ant_d','12j','2litres','orge'),
('3','5','2020-06-25','2020-09-10','complet','2020-09-10','fracture_pos_g','1an','2litres','sucre_paille'),
('1','5','2020-05-23','2020-05-23','complet','2020-05-23','tendinite_pos_d','12j','2litres','poudre'),
('1','2','2020-05-23','2020-06-12','complet','2020-06-12','fracture_pos_g','','2litres','avoine'),
('1','1','2020-05-23','2020-07-11','complet','2020-07-11','tendinite_Ant_g','1mois','2litres','maïs'),
('1','3','2020-05-23','2020-08-12','complet','2020-08-12','infiltration_Pos_d','15j','2litres','poivre'),
('1','3','2020-05-23','2020-05-13','complet','2020-05-13','fracture_Anterieur_g','6mois','2litres','sel')




insert [dbo].[Historique] ([dbo].[Historique].[Id_Cheval],
                           [dbo].[Historique].[Debourage],
                           [dbo].[Historique].[Pre-entrainement],
                           [dbo].[Historique].[Entraineur_precedent],
                           [dbo].[Historique].[Proprietaire_precedent])
values
('2','malenfant','malenfant','dubois','dubuisson'),
('4','perceval','perceval','nami','dubuisson'),
('3','caradoc','perceval','dubois','leona'),
('5','dugarry','marion','leblanc','dubuisson'),
('2','malenfant','malenfant','dubois','kartus');

insert mym_Vaccination_Cheval (ChevalId_Cheval, VaccinationId_Vaccination)

values

('5','1'),
('4','2'),
('3','4'),
('1','5'),
('2','3')


insert mym_Cheval_Entrainement (MYM_ChevaliId_Cheval, MYM_Entrainementid_Entrainement)

values

('5','1'),
('4','2'),
('3','4'),
('1','5'),
('2','3')


insert mym_Course_cheval (ChevalId_Cheval, CoursesId_Course)

values

('5','1'),
('4','2'),
('3','4'),
('1','5'),
('2','3')

insert mym_Cheval_Entrainement (MYM_ChevaliId_Cheval, MYM_Entrainementid_Entrainement)

values 

('5','1'),
('4','2'),
('3','4'),
('1','5'),
('2','3')

