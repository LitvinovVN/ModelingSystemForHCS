# ModelingSystemForHCS
Система моделирования для гетерогенных вычислительных сред

Работа с новыми ветками в Git
1.	Вызовите консоль на экран (ПКМ в локальном репозитории – Git Bash Here).
2.	В консоли наберите команду git branch. Git покажет список веток в проекте с отмеченной текущей веткой.
3.	Для создания ветки наберите команду git checkout –b <имя ветки>. Git сразу переключается в новую ветку. И все изменения сохраняются в новой ветке.
4.	Внесите изменения в проект в локальном репозитории.
5.	Сохраните все изменения в новой ветке (коммит), но не вводите команду git push.
6.	Для переключения в ветку main введите команду git checkout main.
7.	Проверьте содержимое локального репозитория. Оно будет своим для каждой ветки. Для этого переключитесь между ветками.
8.	Для добавления новой ветки branch2 в удаленный репозиторий Git выполните команду git push --set-upstream origin branch2.
9.	Убедитесь в появлении новой ветки branch2 в удаленном репозитории Git.
10.	Перейдите в ветку main, для этого выполните команду git checkout main.
11.	Для слияния двух веток выполните команду git merge <имя ветки, которую мы добавляем к ветке main>.
12.	Убедитесь, что содержимое веток в локальном репозитории одинаковое (переключайтесь между ветками с помощью команды 6).
13.	Выполните команду git push. Содержимое веток в удаленном репозитории будет одинаковое.
14.	Удалим временную ветку branch2 в локальном репозитории. Для этого выполните команду git branch –d <имя удаляемой ветки>.
15.	Команда git branch –a показывает список всех веток в локальном и удаленном репозиториях.
16.	Выполните команду git push origin -d <имя удаляемой ветки> для внесения изменений (для удаления ветки) в удаленный репозиторий.
